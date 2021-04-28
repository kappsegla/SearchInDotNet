using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace ConsoleApp.TextSearch
{
    public class LuceneExample
    {
        public void Run()
        {
            // Ensures index backwards compatibility
            var AppLuceneVersion = LuceneVersion.LUCENE_48;


            var indexLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile,
                Environment.SpecialFolderOption.DoNotVerify), ".DemoApp2020", "Index");

            var dir = FSDirectory.Open(indexLocation);

            //create an analyzer to process the text
            var analyzer = new StandardAnalyzer(AppLuceneVersion);

            //create an index writer
            var indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
            indexConfig.OpenMode = OpenMode.CREATE;
            var writer = new IndexWriter(dir, indexConfig);

            // var source = new
            // {
            //     Name = "Kermit the Frog",
            //     FavoritePhrase = "The quick brown fox jumps over the lazy dog"
            // };
            // Document doc = new Document
            // {
            //     // StringField indexes but doesn't tokenize
            //     new StringField("name", 
            //         source.Name, 
            //         Field.Store.YES),
            //     new TextField("favoritePhrase", 
            //         source.FavoritePhrase, 
            //         Field.Store.YES)
            // };
            var list = new List<string>()
            {
                "My sister is coming for the holidays.",
                "The holidays are a chance for family meeting.",
                "Who did your sister meet?",
                "It takes an hour to make fudge.",
                "My sister makes awesome fudge."
            };

            list.ForEach(s =>
            {
                Document doc = new Document
                {
                    new TextField("body",
                        s,
                        Field.Store.YES)
                };
                writer.AddDocument(doc);
            });
            writer.Flush(triggerMerge: false, applyAllDeletes: false);

            /////
            // re-use the writer to get real-time updates
            /////
            var searcher = new IndexSearcher(writer.GetReader(applyAllDeletes: true));

            // search with a phrase
            // var phrase = new MultiPhraseQuery();
            // phrase.Add(new Term("favoritePhrase", "sister"));
            // phrase.Add(new Term("favoritePhrase", "fudge"));

            //Fuzzy Search
            var phrase = new FuzzyQuery(new Term("body", "saster"), 1);

            var hits = searcher.Search(phrase, 3 /* top 3 */).ScoreDocs;
            foreach (var hit in hits)
            {
                var foundDoc = searcher.Doc(hit.Doc);
                hit.Score.Dump("Score");
                foundDoc.Get("body").Dump("Body");
            }
        }
    }
}
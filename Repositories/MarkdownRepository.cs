using System;
using System.IO;
using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace Masc.MarkdownCICD.Repositories
{
    public class MarkdownRepository {
        public MarkdownRepository(string markdownFilePath) {
            var pipeline = new MarkdownPipelineBuilder()
                .UseYamlFrontMatter()
                .Build();

            // Parse the markdown into a syntax tree
            var document = Markdown.Parse(File.ReadAllText(markdownFilePath), pipeline);

            // Traverse and display the syntax tree
            Console.WriteLine("Original Syntax Tree:");
            Traverse(document);
        }

        static void Traverse(MarkdownObject markdownObject, int depth = 0)
        {
            var indent = new string(' ', depth * 2);
            Console.WriteLine($"{indent}- {markdownObject.GetType().Name}");

            if (markdownObject is ContainerBlock containerBlock)
            {
                foreach (var block in containerBlock)
                {
                    Traverse(block, depth + 1);
                }
            }
            else if (markdownObject is LeafBlock leafBlock)
            {
                if (leafBlock.Inline != null)
                {
                    TraverseInlines(leafBlock.Inline, depth + 1);
                }
            }
        }

        static void TraverseInlines(ContainerInline inline, int depth)
        {
            foreach (var childInline in inline)
            {
                var indent = new string(' ', depth * 2);
                Console.WriteLine($"{indent}- {childInline.GetType().Name}");

                if (childInline is ContainerInline innerContainer)
                {
                    TraverseInlines(innerContainer, depth + 1);
                }
            }
        }
    }
}

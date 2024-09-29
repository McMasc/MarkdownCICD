# Daily

Test CDCD Script

## Cron

``* * * * *``

## Task

```csharp
var fileInfo = Services.MarkdownFiles.GetCurrentDaily();
Services.Markdown.AddHeader(fileInfo, level: 1, title: "title", afterHeader: lastHeader);
fileInfo.Update();
```

## Output

Type: html
Remote: server01

```csharp

```
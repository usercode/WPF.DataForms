# WPF.DataForms
Fluent-based data forms for WPF


## Example ##

```CS
class FileFormMapping : DataFormMapping<FileDetailModule>
    {
        public override void CreateMainContent()
        {
            MainContent.Group(Resources.General)
                          .Label(Resources.Id, x => x.Entity.Id)
                          .Text(Resources.Name, x => x.Entity.Name)
                          .Text(Resources.Url, x => x.Entity.Url)
                          .Text(Resources.MIME, x => x.Entity.MimeType)
              ;
        }
```

Create a data template:

```CS
DataTemplate dataTemplate = new FileFormMapping().CreateTemplate(GuiState.View);
```

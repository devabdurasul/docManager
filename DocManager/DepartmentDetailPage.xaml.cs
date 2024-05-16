namespace DocManager
{
    public partial class DepartmentDetailPage : ContentPage
    {
        public List<DocumentTemplate> DocumentTemplates { get; set; }
        public List<Document> Documents { get; set; }
        public Department Department { get; set; }
        public DepartmentDetailPage()
        {
            InitializeComponent();
        }

        public void Init()
        {
            DepartmentName.Text = Department?.Name;
            OpName.Text = Department?.OperatorName;
            Desc.Text = Department?.Description;

            // Initialize test data for DocumentTemplates
            DocumentTemplates = new List<DocumentTemplate>
            {
                new DocumentTemplate { TemplateName = "Ариза барои фалон", TemplateDescription = "Шаблон барои навиштани Ариза барои фалон" },
                new DocumentTemplate { TemplateName = "Пешниҳоди лоиҳа", TemplateDescription = "Шаблон барои навиштани пешниҳодҳои лоиҳа" },
                new DocumentTemplate { TemplateName = "Ҳисоботи хароҷот", TemplateDescription = "Шаблон барои навиштани Ҳисоботи хароҷот" },
                new DocumentTemplate { TemplateName = "Рӯзномаи ҷаласа", TemplateDescription = "Шаблон барои навиштани Рӯзномаи ҷаласа" },
            };

            docTemplates.ItemsSource = DocumentTemplates;


            // Initialize test data for Documents
            Documents = new List<Document>
            {
                new Document
                {
                     DocumentName = "Ариза барои пешапардохт",
                     DocumentTitle = "Ариза барои пешапрдохт",
                     DocumentNumber = "MS-2024-234",
                     DocumentContent = "Ин Аризаи маркетинги пешниҳодшударо барои соли 2024 муайян мекунад...",
                     DocumentStatus = DocumentStatus.Rejected
                },
                new Document
                {
                     DocumentName = "Пешниҳод барои стратегияи маркетинг",
                     DocumentTitle = "Пешниҳоди стратегияи маркетингӣ",
                     DocumentNumber = "MS-2023-001",
                     DocumentContent = "Ин ҳуҷҷат стратегияи маркетинги пешниҳодшударо барои соли 2023 муайян мекунад...",
                     DocumentStatus = DocumentStatus.Rejected
                },
                new Document
                {
                    DocumentName = "Ҳисоботи молиявӣ дар семоҳаи ...",
                    DocumentTitle = "Ҳисоботи молиявӣ барои семоҳаи ...",
                    DocumentNumber = "FR-2023-Q1",
                    DocumentContent = "Ин гузориш натиҷаҳои молиявии ширкатро дар семоҳаи аввали соли 2023 ҷамъбаст мекунад...",
                    DocumentStatus = DocumentStatus.Approved
                },
                new Document
                {
                    DocumentName = "Дастурномаи кормандон",
                    DocumentTitle = "Дастур барои кормандон",
                    DocumentNumber = "EH-2023",
                    DocumentContent = "Дастури корманд дорои маълумоти муҳим дар бораи сиёсатҳо, расмиёти ширкат ва имтиёзҳо мебошад...",
                    DocumentStatus = DocumentStatus.Ready
                }
            };
            MyDocuments.ItemsSource = Documents;
        }

        private void Entry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void docSearch_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void docTemplateSearch_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }
    }

    public class DocumentTemplate
    {
        public string TemplateName { get; set; }
        public string TemplateDescription { get; set; }
    }

    public class Document
    {
        public string DocumentName { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentContent { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
    }

    public enum DocumentStatus
    {
        Draft,
        Rejected,
        Approved,
        Ready
    }
}

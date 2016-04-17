using System.Collections.Generic;
using System.IO;
using DevExpress.Utils;

namespace PHRMS.ViewModels
{
    public class MailMergeTemplatesHelper
    {
        private static readonly string[] templateNames =
        {
            "Employee of the Month.rtf",
            "Employee Probation Notice.rtf",
            "Employee Service Excellence.rtf",
            "Employee Thank You Note.rtf",
            "Welcome to DevAV.rtf",
            "Sales Thank You.rtf"
        };

        public static List<TemplateViewModel> GetAllTemplates()
        {
            var templates = new List<TemplateViewModel>();
            foreach (var name in templateNames)
            {
                var stream = GetTemplateStream(name);
                templates.Add(new TemplateViewModel
                {
                    Name = name.Replace(".rtf", "")
                });
            }
            return templates;
        }

        public static Stream GetTemplateStream(string templateName)
        {
            return AssemblyHelper.GetEmbeddedResourceStream(typeof(MailMergeTemplatesHelper).Assembly, templateName,
                false);
        }
    }

    public class TemplateViewModel
    {
        public string Name { get; set; }

        public Stream Template
        {
            get
            {
                return AssemblyHelper.GetEmbeddedResourceStream(typeof(MailMergeTemplatesHelper).Assembly, Name + ".rtf",
                    false);
            }
        }
    }
}
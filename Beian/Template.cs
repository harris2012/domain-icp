using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beian
{
    public class Template
    {
        public Domain Domain { get; set; }

        public string TransformText()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"<!DOCTYPE html>");
            builder.AppendLine();
            builder.AppendLine($"<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\">");
            builder.AppendLine($"<head>");
            builder.AppendLine($"    <meta charset=\"utf-8\" />");
            builder.AppendLine($"    <title>{this.Domain.Title}</title>");
            builder.AppendLine($"</head>");
            builder.AppendLine($"<body>");
            builder.AppendLine();
            builder.AppendLine($"    <p>欢迎访问 {this.Domain.Title}</p>");
            builder.AppendLine();
            builder.AppendLine($"    <p><a href=\"http://www.beian.miit.gov.cn/\" target=\"_blank\">{this.Domain.ICP}</a></p>   ");
            builder.AppendLine();
            builder.AppendLine($"</body>");
            builder.AppendLine($"</html>");

            return builder.ToString();
        }
    }
}

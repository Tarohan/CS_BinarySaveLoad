using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace 設定ファイルテスト
{
    public class InOut
    {
        public int fromDate;
        public int toDate;

        public void SaveXml(string path, int fromDate, int toDate)
        {
            XElement root =
                new XElement("root",
                    new XElement("filePath", path),
                    new XElement("fromDate", fromDate.ToString()),
                    new XElement("toDate", toDate.ToString())
                );

            root.Save("test.xml");
        }
    }
}

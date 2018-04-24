using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 設定ファイルテスト
{
    [Serializable()]
    public class Setting
    {
        private string _stringPath;

        public string StringPath
        {
            get { return _stringPath; }
            set { _stringPath = value; }
        }

        public Setting(string str)
        {
            _stringPath = str;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace HttpPracticeConsoleApp
{
    [DataContract(Name="repo")]
    public class Repository
    {
        [DataMember(Name = "name")]
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        private string _name;
    }
}

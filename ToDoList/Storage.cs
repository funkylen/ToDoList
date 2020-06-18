﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ToDoList.Items;

namespace ToDoList
{
    [Serializable]
    public class Storage
    {
        XmlSerializer formatter = new XmlSerializer(typeof(List<Tasks>));

        public List<Tasks> SetFileXML(List<Tasks> task)
        {         
            using (FileStream fs = new FileStream("DataBase.xml", FileMode.Create))
            {
                formatter.Serialize(fs, task);
            }

            return task;
        }        
        
        public List<Tasks> GetFileXML(List<Tasks> task)
        {                         
            using (FileStream fs = new FileStream("DataBase.xml", FileMode.Open))
            {
                task = (List<Tasks>)formatter.Deserialize(fs);
            }

            return task;
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToDoList.Items;

namespace ToDoList
{
    class App : IApp
    {
        Storage storage = new Storage();
        List<Tasks> TasksBox = new List<Tasks>();

        public App()
        {
            foreach (Tasks task in storage.GetFileXML(TasksBox))
            {
                TasksBox.Add(task);
            }
        }

        public List<Tasks> GetTasks()
        {
            return TasksBox;
        }

        public Tasks Add(string TaskText)
        {
            Tasks task = new Tasks(TaskText, TasksBox);

            TasksBox.Add(task);

            storage.SetFileXML(TasksBox);

            return task;
        }

        public bool Delete(int TaskId)
        {
            /**
             * А что если не найдется task? Тогда надо вернуть false
             * @TODO: в блоке if сохрани изменения в файле и верни true
             * Если будет пройден весь цикл и не сделано изменений - false
             */
            foreach (Tasks task in TasksBox)
            {
                if (task.Id == TaskId)
                {
                    TasksBox.Remove(task);
                    break;
                }
            }

            storage.SetFileXML(TasksBox);

            return true;
        }

        public bool Complete(int TaskId)
        {
            /**
             * А что если не найдется task? Тогда надо вернуть false
             * @TODO: в блоке if сохрани изменения в файле и верни true
             * Если будет пройден весь цикл и не сделано изменений - false
             */
            foreach (Tasks task in TasksBox)
            {
                if (task.Id == TaskId)
                {
                    task.Check = true;
                    break;
                }
            }

            storage.SetFileXML(TasksBox);

            return true;
        }

        public bool Uncomplete(int TaskId)
        {
            /**
             * А что если не найдется task? Тогда надо вернуть false
             * @TODO: в блоке if сохрани изменения в файле и верни true
             * Если будет пройден весь цикл и не сделано изменений - false
             */
            foreach (Tasks task in TasksBox)
            {
                if (task.Id == TaskId)
                {
                    task.Check = false;
                    break;
                }
            }
            storage.SetFileXML(TasksBox);
            return true;
        }
    }
}

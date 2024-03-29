﻿using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.WebUI.Tests.Mocks
{
  public  class MockContext<T> : IRepository<T> where T : BaseEntity
    {
        List<T> items;

        string ClassName ="";

        public MockContext()
        {
            items = new List<T>();
        }

        public void Commit()
        {
            return;
        }

        public T Insert(T t)
        {
            items.Add(t);
            return t;
        }

        public T Update(T t)
        {
            T tToUpdate = items.Find(i => i.Id == t.Id);
            if (tToUpdate != null)
            {
                tToUpdate = t;
                return tToUpdate;
            }

            else
            {
                throw new Exception(ClassName + ": Record not found");
            }
        }

        public T Find(string Id)
        {
            T t = items.Find(i => i.Id == Id);
            if (t != null)
            {
                return t;
            }
            else
            {
                throw new Exception(ClassName + ": Not found!");
            }
        }


        public IEnumerable<T> Collection()
        {
            return items.ToList();
        }

        public void Delete(string Id)
        {
            T tToDelete = items.Find(i => i.Id == Id);

            if (tToDelete != null)
            {
                items.Remove(tToDelete);
            }
            else
            {
                throw new Exception(ClassName + ": Not found!");
            }
        }
    }
}

using IT.specialist.article.archiv.Data.DB;
using IT_specialist_article_archiv.Models;
using IT_specialist_article_archiv.Services;
using System;
using System.Collections.ObjectModel;

namespace IT.specialist.article.archiv.Service
{
    public class ServiceArchiv : IServiceArchiv
    {
        private RepositroyArchiv repositoryArchiv = new RepositroyArchiv();

        public bool Delete(int id) => repositoryArchiv.Delete(id);

        public bool Delte(Archiv obj) => repositoryArchiv.Delte(obj);

        public Archiv Get(int id) => repositoryArchiv.Get(id);

        public ObservableCollection<Archiv> GetAll() => repositoryArchiv.GetAll();

        public bool Save(Archiv obj) => repositoryArchiv.Save(obj);
    }
}

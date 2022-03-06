using System;
using System.Collections.Generic;
using System.Linq;
using TesteTecnicoDanielZanelato.Models;

namespace TesteTecnicoDanielZanelato.Services
{
    public class Repository
    {
        private List<IModel> _fakeDatabase = new List<IModel>();

        public void Insert(IModel model)
        {
            if (model.Id == Guid.Empty)
                throw new Exception("Não é possível salver um registro com Id não preenchido");

            var modelAlreadyExists = _fakeDatabase.Any(savedModel => savedModel.Id == model.Id);
            if (modelAlreadyExists)
                throw new Exception($"Já existe um registro para a entidade '{model.GetType().Name}' com o Id '{model.Id}'");
            var lastElement = _fakeDatabase.Count();
            if (lastElement == 0)
            {
                _fakeDatabase.Add(model);
            }
            else
            {
                _fakeDatabase.Insert(lastElement, model);
            }
        }
        public void Update(IModel model)
        {
            var updatingModel = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == model.Id);
            if (updatingModel == null)
                throw new Exception($"Não há registros para a entidade '{model.GetType().Name}' com Id '{model.Id}'");

            _fakeDatabase.Remove(updatingModel);
            _fakeDatabase.Add(model);
        }
        public T GetById<T>(Guid id)
        {
            return (T)_fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == id);
        }
        public List<T> GetAll<T>()
        {
            var allModels = _fakeDatabase.Where(savedModel => savedModel.GetType().IsAssignableFrom(typeof(T)));
            return allModels.Select(genericModel => (T)genericModel).ToList();
        }
    }
}

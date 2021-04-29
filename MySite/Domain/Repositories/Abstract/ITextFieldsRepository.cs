using System;
using System.Linq;
using MySite.Domain.Entities;

namespace MySite.Domain.Repositories.Abstract
{
    public interface ITextFieldsRepository
    {
        IQueryable<TextField> GetTextFields();
        TextField GetTextFieldById(Guid id);
        TextField GetTextFieldByCodeWord(string codeWord);
        void SaveTextField(TextField entity);
        void DeleteTextField(Guid id);
    }
}

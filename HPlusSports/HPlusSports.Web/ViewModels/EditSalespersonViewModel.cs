using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HPlusSports.Models;

namespace HPlusSports.Web.ViewModels
{
    public class EditSalespersonViewModel
    {
        Salesperson _person;
        public EditSalespersonViewModel()
        {
            _person = new Salesperson();
        }

        public EditSalespersonViewModel(Salesperson person)
        {
            _person = person;
        }

        public int Id { get { return _person.Id; }  set { _person.Id = value; } }
        public string FirstName { get { return _person.FirstName; } set { _person.FirstName = value; } }
        public string LastName { get { return _person.LastName; } set { _person.LastName = value; } }
        public string Email { get { return _person.Email; } set { _person.Email = value; } }
        public string Phone { get { return _person.Phone; } set { _person.Phone = value; } }

        public Salesperson GetPerson()
        {
            return _person;
        }
    }
}

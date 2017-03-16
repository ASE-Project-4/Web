﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogic
{
    interface IUserEdit
    {

        // USER EDIT________________________________________
        //Ændre users 
        //Postcondition:
        //Retunerer true, hvis update af first name lykkedes, eller false.
        bool updateFirstName(string currentUsername, string firstName);
        //Postcondition:
        //Retunerer true, hvis update af last name lykkedes, eller false.
        bool updateLastName(string currentUsername, string LastName);
        //Postcondition:
        //Retunerer true, hvis update af email lykkedes, eller false.
        bool updateEmail(string currentUsername, string email);
        //Postcondition:
        //Retunerer true, hvis update af password lykkedes, eller false.
        bool updatePassword(string currentUsername, string password);
        //Postcondition:
        //Retunerer true, hvis delete af user lykkedes, eller false.
        bool deleteUser(string currentUsername);

        //Lobby funktionaliteter


    }
}

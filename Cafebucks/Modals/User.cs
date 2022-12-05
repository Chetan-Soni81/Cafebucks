using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cafebucks.Modals
{
    public class User
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobileno { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public bool SpeakHindi { get; set; }
        public bool SpeakEnglish { get; set; }
        public string ImagePath { get; set; }

        override
        public string ToString()
        {
            string str = $"Username: {Username}\nName: {Name}\nE-mail: {Email}\nMobile No.: {Mobileno}\nPassword: {Password}\nGender: {Gender}\nSpeaks Hindi: {SpeakHindi}\nSpeaks English: {SpeakEnglish}";
            return str;
        }

        public string ToHtmlString()
        {
            string str = $"<p>Username: {Username}</p><p>Name: {Name}</p><p>E-mail: {Email}</p><p>Mobile No.: {Mobileno}</p><p>Password: {Password}</p><p>Gender: {Gender}</p><p>Speaks Hindi: {SpeakHindi}</p><p>Speaks English: {SpeakEnglish}</p>";
            return str;
        }
    }

}
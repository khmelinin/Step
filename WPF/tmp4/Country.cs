using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmp4
{
    [Serializable]
    class Country
    {
        string name = "";
        string photo = "";
        string video = "";
        string description = "";
        string facts = "";
        string dishes = "";
        string curency = "";
        string timezone = "";
        string weather = "";
        string sights = "";
        string warnings = "";
        string prices = "";

        public string ToStringShort()
        {
            return name;
        }
        public string ToStringLong()
        {
            return name + "\r\n" + photo + "\r\n" + video + "\r\n" + description + "\r\n" + facts + "\r\n" + dishes + "\r\n" + curency + "\r\n" + timezone + "\r\n" + weather + "\r\n" + sights + "\r\n" + warnings + "\r\n" + prices;
        }

        public Country() { }

        public Country(string name)
        {
            this.Name = name;
        }

        public Country(string name, string photo, string video, string description, string facts, string dishes, string curency, string timezone, string weather, string sights, string warnings, string prices)
        {
            this.Name = name;
            this.Photo = photo;
            this.Video = video;
            this.Description = description;
            this.Facts = facts;
            this.Dishes = dishes;
            this.Curency = curency;
            this.Timezone = timezone;
            this.Weather = weather;
            this.Sights = sights;
            this.Warnings = warnings;
            this.Prices = prices;
        }

        public string Name { get => name; set => name = value; }
        public string Photo { get => photo; set => photo = value; }
        public string Video { get => video; set => video = value; }
        public string Description { get => description; set => description = value; }
        public string Facts { get => facts; set => facts = value; }
        public string Dishes { get => dishes; set => dishes = value; }
        public string Curency { get => curency; set => curency = value; }
        public string Timezone { get => timezone; set => timezone = value; }
        public string Weather { get => weather; set => weather = value; }
        public string Sights { get => sights; set => sights = value; }
        public string Warnings { get => warnings; set => warnings = value; }
        public string Prices { get => prices; set => prices = value; }
    }
}

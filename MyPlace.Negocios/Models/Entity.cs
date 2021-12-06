using System;

namespace MyPlace.Negocios
{
    public abstract class Entity{

        protected Entity(){
            id = Guid.NewGuid();
        }

        public Guid id { get; set; }
    }
}
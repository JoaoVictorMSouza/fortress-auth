namespace FortressAuth.Domain.Entities.Base
{
    public abstract class DefaultEntity<TypeId> : DefaultEntityNoKey
    {
        protected DefaultEntity(TypeId id) : base()
        {
            this.Id = id;
        }

        public TypeId Id { get; private set; }
    }
}

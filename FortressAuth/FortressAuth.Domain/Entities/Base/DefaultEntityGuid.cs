namespace FortressAuth.Domain.Entities.Base
{
    public abstract class DefaultEntityGuid : DefaultEntity<Guid>
    {
        protected DefaultEntityGuid() : base(Guid.NewGuid())
        {

        }
    }
}

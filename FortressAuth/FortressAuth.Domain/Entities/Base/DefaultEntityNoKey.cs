namespace FortressAuth.Domain.Entities.Base
{
    public abstract class DefaultEntityNoKey
    {
        protected DefaultEntityNoKey()
        {
            IsInactive = false;
            DhInclusion = DateTime.UtcNow;
            DhChange = null;
        }

        public bool IsInactive { get; private set; }
        public DateTime? DhInclusion { get; private set; }
        public DateTime? DhChange { get; private set; }

        public void SetDhChange(DateTime dhChange)
        {
            DhChange = dhChange;
        }
    }
}

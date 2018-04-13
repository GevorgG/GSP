namespace OmniSenseNetwork.GSP.Common.Helpers
{
    public class TypeSafeCollection
    {
        private readonly string _name;

        protected TypeSafeCollection(string name)
        {
            _name = name;
        }

        public override string ToString() => _name;
    }
}

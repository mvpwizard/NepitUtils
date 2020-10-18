namespace NepitUtils.Encoding
{
    internal interface IMapping
    {
        public string this[int val] { get; }
        public int this[string val] { get; }
        public int Quantum { get; }
        public string Padding { get; }
    }
}

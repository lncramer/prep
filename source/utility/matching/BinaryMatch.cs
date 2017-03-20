namespace code.utility.matching
{
    public class BinaryMatch<Item> : IMatchA<Item>
    {
        private readonly IMatchA<Item> _left;
        private readonly IMatchA<Item> _right;
        private readonly BinaryMatchType _binaryMatchType;

        public delegate bool BinaryMatchType(IMatchA<Item> condition1, IMatchA<Item> condition2);

        public BinaryMatch(IMatchA<Item> left, IMatchA<Item> right, BinaryMatchType binaryMatchType)
        {
            _left = left;
            _right = right;
            _binaryMatchType = binaryMatchType;
        }

        public bool matches(Item item)
        {
            return _binaryMatchType(_left.matches(item), _right.matches(item));
        }
    }
}
namespace RegexSimpleBuilder;

public sealed class MissingGroupElementsException()
    : Exception("The group must have at least one element that renders to at least once character in length");
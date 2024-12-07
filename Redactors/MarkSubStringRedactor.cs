using Microsoft.Extensions.Compliance.Redaction;

namespace AnhTran.RedactingSensitiveData.Redactors
{
    public class MarkSubStringRedactor : Redactor
    {
        private const char _mask = '*';
        private const int _numberOfCharsToKeep = 4;

        public override int GetRedactedLength(ReadOnlySpan<char> input)
        {
            return input.Length;
        }

        public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
        {

            for (int i = 0; i < destination.Length; i++)
            {
                if (i > _numberOfCharsToKeep)
                {
                    destination[i] = _mask;
                }
                else
                {
                    destination[i] = source[i];
                }
            }

            return destination.Length;
        }
    }
}

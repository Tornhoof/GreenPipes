namespace GreenPipes.Specifications
{
    using System.Collections.Generic;
    using Filters;


    /// <summary>
    /// Adds a fork to the pipe
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class InterceptPipeSpecification<TContext> :
        IPipeSpecification<TContext>
        where TContext : class, PipeContext
    {
        readonly IPipe<TContext> _pipe;

        public InterceptPipeSpecification(IPipe<TContext> pipe)
        {
            _pipe = pipe;
        }

        public void Apply(IPipeBuilder<TContext> builder)
        {
            builder.AddFilter(new InterceptFilter<TContext>(_pipe));
        }

        public IEnumerable<ValidationResult> Validate()
        {
            if (_pipe == null)
                yield return this.Failure("Pipe", "must not be null");
        }
    }
}

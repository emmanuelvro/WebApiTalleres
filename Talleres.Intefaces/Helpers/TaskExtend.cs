using System.Runtime.CompilerServices;

namespace System.Threading.Tasks
{
    public static class TaskExtend
    {
        public static ConfiguredTaskAwaitable ConfigureAwait(this Task task)
        {
            return task.ConfigureAwait(false);
        }

        public static ConfiguredTaskAwaitable<T> ConfigureAwait<T>(this Task<T> task)
        {
            return task.ConfigureAwait(false);
        }
    }
}
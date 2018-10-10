using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    /// <summary>
    /// Various helper functions to make a DokuExtractor's life easier.
    /// </summary>
    public static class HelperExtensions
    {
        /// <summary>
        /// Waits asynchronously for the process to exit.
        /// </summary>
        /// <param name="process">The process to wait for cancellation.</param>
        /// <param name="cancellationToken">A cancellation token. If invoked, the task will return 
        /// immediately as canceled.</param>
        /// <returns>A Task representing waiting for the process to end.</returns>
        public static Task WaitForExitAsync(this Process process,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tcs = new TaskCompletionSource<object>();
            process.EnableRaisingEvents = true;
            process.Exited += (sender, args) => tcs.TrySetResult(null);
            if (cancellationToken != default(CancellationToken))
                cancellationToken.Register(tcs.SetCanceled);

            return tcs.Task;
        }

        /// <summary>
        /// Turns [Hello] into ["Hello"].
        /// </summary>
        /// <param name="inputText">Text that shall be encapsulated</param>
        /// <returns></returns>
        public static string EncapsulateInDoubleQuotes(this string inputText)
        {
            return "\"" + inputText + "\"";
        }

        /// <summary>
        /// Concatinates all strings from a collection. Each entry will be separated by the seperator from the next entry.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public static string ConcatList(this IEnumerable<string> input, string seperator)
        {
            var builder = new StringBuilder();

            foreach (var item in input)
            {
                builder.Append(item);
                builder.Append(seperator);
            }


            return builder.ToString();
        }

        /// <summary>
        /// Turns a string enumerable into a hash set.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="ignoreDoubleEntries">Decides what to do if the string enumerable contains more than one entry with the same value. True: Ignore the additional ones and just add it to the hash set once. False: Throw exception. </param>
        /// <returns></returns>
        public static HashSet<string> ToHashSet(this IEnumerable<string> input, bool ignoreDoubleEntries = true)
        {
            var retVal = new HashSet<string>();

            foreach (var item in input)
            {
                if (ignoreDoubleEntries)
                {
                    if (retVal.Contains(item) == false)
                        retVal.Add(item);
                }
                else
                    retVal.Add(item);
            }

            return retVal;
        }

        /// <summary>
        /// Clones an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceObject">object which shall be cloned</param>
        /// <returns></returns>
        public static T JsonDeepClone<T>(this T sourceObject)
        {
            var jsonClone = JsonConvert.SerializeObject(sourceObject);
            var retVal = JsonConvert.DeserializeObject<T>(jsonClone);
            return retVal;
        }
    }
}

using System; // Console
using System.Collections.Generic; // Dictionary

namespace ItTechGenie.M1.OOP.Q6
{
    public class HelpDesk
    {
        public static void Run()
        {
            Console.WriteLine("Paste input lines, end with EMPTY line:");
            var lines = ConsoleInput.ReadLines();

            var engine = new TicketEngine();
            engine.Run(lines);
        }
    }

    public static class ConsoleInput
    {
        public static string[] ReadLines()
        {
            var list = new List<string>();
            while (true)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) break;
                list.Add(line);
            }
            return list.ToArray();
        }
    }

    public class TicketEngine
    {
        private readonly Dictionary<string, Ticket> _tickets = new();

        public void Run(string[] lines)
        {
            foreach (var raw in lines)
            {
                var cmd = Command.Parse(raw);

                if (cmd.Name == "TICKET_NEW")
                {
                    var id = cmd.Get("id");
                    var type = cmd.Get("type");
                    var title = cmd.Get("title");
                    var desc = cmd.Get("desc");
                    _tickets[id] = new Ticket(id, type, title, desc);
                    Console.WriteLine($"Created ticket {id} in state NEW");
                }
                else if (cmd.Name == "MOVE")
                {
                    var id = cmd.Get("id");
                    var to = cmd.Get("to");
                    var by = cmd.Get("by");
                    _tickets[id].MoveTo(to, by);                                // ✅ TODO transitions
                }
            }
        }
    }

    public class Ticket
    {
        public string Id { get; }
        public string Type { get; }
        public string Title { get; }
        public string Description { get; }

        private ITicketState _state = new NewState();                           // initial state

        public Ticket(string id, string type, string title, string description)
        {
            Id = id; Type = type; Title = title; Description = description;     // assign
        }

        // ✅ TODO: Student must implement only this method
        public void MoveTo(string nextStateName, string actor)
        {
            // TODO:
            // - Convert nextStateName into ITicketState using StateFactory.FromString
            // - Ask current state to validate transition
            // - If allowed, switch _state and print transition line
            var nextState = StateFactory.FromString(nextStateName);
            _state.MoveNext(nextState);  
            Console.WriteLine($"Ticket {Id}: {_state.Name} -> {nextState.Name} by {actor}");
            _state = nextState; 
        }
    }

    public interface ITicketState
    {
        string Name { get; }                                                    // state name
        void MoveNext(ITicketState next);                                       // validate transition
    }

    public sealed class NewState : ITicketState
    {
        public string Name => "New";
        public void MoveNext(ITicketState next)
        {
            if (next is not InProgressState) throw new InvalidOperationException("New -> only InProgress allowed");
        }
    }

    public sealed class InProgressState : ITicketState
    {
        public string Name => "InProgress";
        public void MoveNext(ITicketState next)
        {
            if (next is not ResolvedState) throw new InvalidOperationException("InProgress -> only Resolved allowed");
        }
    }

    public sealed class ResolvedState : ITicketState
    {
        public string Name => "Resolved";

        // ✅ TODO: Student must implement only this method
        public void MoveNext(ITicketState next)
        {
            // TODO:
            // - Resolved should NOT allow any transition
            // - throw InvalidOperationException with clear message
            throw new InvalidOperationException("Resolved -> no transitions allowed");
        }
    }

    public static class StateFactory
    {
        // ✅ TODO: Student must implement only this method
        public static ITicketState FromString(string stateName)
        {
            // TODO:
            // - accept "New", "InProgress", "Resolved" (case-insensitive)
            // - return correct state object
            // - throw for unknown state
            
            if (stateName.Equals("New",StringComparison.OrdinalIgnoreCase))
            {
                return new NewState();
            }
            if (stateName.Equals("InProgress",StringComparison.OrdinalIgnoreCase))
            {
                return new InProgressState();
            }
            if (stateName.Equals("Resolved",StringComparison.OrdinalIgnoreCase))
            {
                return new ResolvedState();
            }

            throw new Exception("State is not valid..");
            
        }
        
    }

    public class Command
    {
        public string Name { get; }
        private readonly Dictionary<string, string> _kv;

        private Command(string name, Dictionary<string, string> kv){ Name = name; _kv = kv; }
        public string Get(string key) => _kv.TryGetValue(key, out var v) ? v : "";

        public static Command Parse(string line)
        {
            var parts = line.Split('|');
            var name = parts[0].Trim();
            var kv = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            for (int i = 1; i < parts.Length; i++)
            {
                var p = parts[i];
                var idx = p.IndexOf('=');
                if (idx <= 0) continue;
                var key = p.Substring(0, idx).Trim();
                var val = p.Substring(idx + 1).Trim().Trim('"');
                kv[key] = val;
            }
            return new Command(name, kv);
        }
    }
}
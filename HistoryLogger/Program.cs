using HistoryLogger;
using HistoryLogger.Enums;
using HistoryLogger.Model;

HistoryService historyService = new();

historyService.AddHistoryAsync<Foo>(EventType.Add, "Foo", "Foo", "Foo").Wait();

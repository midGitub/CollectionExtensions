﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CollectionExtensions;

namespace ExampleUsage
{
    internal static class Program
    {
        public static void Main()
        {
            TestDictionary();
            TestList();
            TestObservableCollection();
            Console.ReadKey();
        }

        private static void TestDictionary()
        {
            Console.WriteLine("Dictionary Test:");
            Console.WriteLine("");
            var dictionary = new Dictionary<string, string>();
            dictionary.AddIfNotExists("a", "abc");
            dictionary.AddIfNotExists("a", "abc");
            dictionary.AddIfNotExists("b", "def");
            PrintDictionaryToConsole(dictionary);
            dictionary.Update("b", "defg");
            PrintDictionaryToConsole(dictionary);
            var pair = dictionary.First(x => x.Key.Equals("b"));
            dictionary.Update(pair);
            PrintDictionaryToConsole(dictionary);
            dictionary.DeleteIfExistsKey("a");
            PrintDictionaryToConsole(dictionary);
            dictionary.DeleteIfExistsValue("defg");
            PrintDictionaryToConsole(dictionary);
            Print(dictionary.AreKeysEmpty());
            Print(dictionary.AreValuesEmpty());
            var dict1 = new Dictionary<string, string>();
            var dict2 = dict1.Clone();
            dict2.Add("1", "1");
            PrintDictionaryToConsole(dict1);
            PrintDictionaryToConsole(dict2);
        }

        private static void TestObservableCollection()
        {
            Console.WriteLine("ObservableCollection Test:");
            Console.WriteLine("");
            var observableCollection = new ObservableCollection<string>();
            observableCollection.AddIfNotExists("a");
            observableCollection.AddIfNotExists("a");
            observableCollection.AddIfNotExists("b");
            PrintObservableCollectionToConsole(observableCollection);
            observableCollection.DeleteIfExists("a");
            PrintObservableCollectionToConsole(observableCollection);
            observableCollection.UpdateValue("b", "c");
            PrintObservableCollectionToConsole(observableCollection);
            observableCollection.DeleteIfExists("c");
            PrintObservableCollectionToConsole(observableCollection);
            Print(observableCollection.AreValuesEmpty());
            var observableCollection1 = new ObservableCollection<string>();
            var observableCollection2 = observableCollection1.Clone();
            observableCollection2.Add("Abc");
            PrintObservableCollectionToConsole(observableCollection1);
            PrintObservableCollectionToConsole(observableCollection2);
        }

        private static void TestList()
        {
            Console.WriteLine("List Test:");
            Console.WriteLine("");
            var list = new List<string>();
            list.AddIfNotExists("a");
            list.AddIfNotExists("a");
            list.AddIfNotExists("b");
            PrintListToConsole(list);
            list.DeleteIfExists("a");
            PrintListToConsole(list);
            list.UpdateValue("b", "c");
            PrintListToConsole(list);
            list.DeleteIfExists("c");
            PrintListToConsole(list);
            Print(list.AreValuesEmpty());
            var list1 = new List<string>();
            var list2 = list1.Clone();
            list2.Add("Abc");
            PrintListToConsole(list1);
            PrintListToConsole(list2);
        }

        private static void PrintObservableCollectionToConsole(ObservableCollection<string> collection)
        {
            if (!collection.Any())
                Console.WriteLine("Empty collection");
            else
                foreach (var value in collection)
                    Console.WriteLine(value);
            Console.WriteLine("-------------------------------------");
        }

        private static void PrintListToConsole(IEnumerable<string> list)
        {
            var enumerable = list as string[] ?? list.ToArray();
            if (!enumerable.Any())
                Console.WriteLine("Empty list");
            else
                foreach (var value in enumerable)
                    Console.WriteLine(value);
            Console.WriteLine("-------------------------------------");
        }

        private static void PrintDictionaryToConsole(Dictionary<string, string> dictionary)
        {
            if (dictionary.Count == 0)
                Console.WriteLine("Empty dictionary");
            else
                foreach (var pair in dictionary)
                    Console.WriteLine(pair.Key + ":" + pair.Value);
            Console.WriteLine("-------------------------------------");
        }

        private static void Print(bool value)
        {
            Console.WriteLine(value);
            Console.WriteLine("-------------------------------------");
        }
    }
}
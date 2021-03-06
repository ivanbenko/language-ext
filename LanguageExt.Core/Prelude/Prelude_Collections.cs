﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using LanguageExt.TypeClasses;
using System.Threading.Tasks;

namespace LanguageExt
{
    public static partial class Prelude
    {
        /// <summary>
        /// Construct a list from head and tail
        /// head becomes the first item in the list
        /// Is lazy
        /// </summary>
        [Pure]
        public static IEnumerable<T> Cons<T>(this T head, IEnumerable<T> tail)
        {
            yield return head;
            foreach (var item in tail)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Construct a list from head and tail
        /// </summary>
        [Pure]
        public static Lst<T> Cons<T>(this T head, Lst<T> tail) =>
            tail.Insert(0, head);

        /// <summary>
        /// Lazily generate a range of integers.  
        /// </summary>
        [Pure]
        public static IEnumerable<int> Range(int from, int count, int step = 1) =>
            IntegerRange.FromCount(from, count, step);

        /// <summary>
        /// Lazily generate a range of chars.  
        /// 
        ///   Remarks:
        ///     Can go in a positive direction ('a'..'z') as well as negative ('z'..'a')
        /// </summary>
        [Pure]
        public static IEnumerable<char> Range(char from, char to) =>
            CharRange.FromMinMax(from, to);

        /// <summary>
        /// Lazily generate integers from any number of provided ranges
        /// </summary>
        [Pure]
        public static IEnumerable<int> Range(params IEnumerable<int>[] ranges) =>
            from range in ranges
            from i in range
            select i;

        /// <summary>
        /// Lazily generate chars from any number of provided ranges
        /// </summary>
        [Pure]
        public static IEnumerable<char> Range(params IEnumerable<char>[] ranges) =>
            from range in ranges
            from c in range
            select c;

        /// <summary>
        /// Create an immutable map
        /// </summary>
        [Pure]
        public static Map<K, V> Map<K, V>() =>
            LanguageExt.Map.empty<K, V>();

        /// <summary>
        /// Create an immutable map
        /// </summary>
        [Pure]
        public static Map<K, V> Map<K, V>(Tuple<K, V> head, params Tuple<K, V>[] tail) =>
            LanguageExt.Map.create(head, tail);

        /// <summary>
        /// Create an immutable map
        /// </summary>
        [Pure]
        public static Map<K, V> Map<K, V>((K, V) head, params (K, V)[] tail) =>
            LanguageExt.Map.create(head, tail);

        /// <summary>
        /// Create an immutable map
        /// </summary>
        [Pure]
        public static Map<K, V> Map<K, V>(KeyValuePair<K, V> head, params KeyValuePair<K, V>[] tail) =>
            LanguageExt.Map.create(head, tail);

        /// <summary>
        /// Create an immutable map
        /// </summary>
        [Pure]
        public static Map<K, V> toMap<K, V>(IEnumerable<Tuple<K, V>> items) =>
            LanguageExt.Map.createRange(items);

        /// <summary>
        /// Create an immutable map
        /// </summary>
        [Pure]
        public static Map<K, V> toMap<K, V>(IEnumerable<(K, V)> items) =>
            LanguageExt.Map.createRange(items);

        /// <summary>
        /// Create an immutable map
        /// </summary>
        [Pure]
        public static Map<K, V> toMap<K, V>(IEnumerable<KeyValuePair<K, V>> items) =>
            LanguageExt.Map.createRange(items);



        /// <summary>
        /// Create an immutable map
        /// </summary>
        [Pure]
        public static Map<OrdK, K, V> Map<OrdK, K, V>() where OrdK : struct, Ord<K> =>
            LanguageExt.Map.empty<OrdK, K, V>();

        /// <summary>
        /// Create an immutable map
        /// </summary>
        [Pure]
        public static Map<OrdK, K, V> Map<OrdK, K, V>(Tuple<K, V> head, params Tuple<K, V>[] tail) where OrdK : struct, Ord<K> =>
            LanguageExt.Map.create<OrdK, K, V>(head, tail);

        /// <summary>
        /// Create an immutable map
        /// </summary>
        [Pure]
        public static Map<OrdK, K, V> Map<OrdK, K, V>((K, V) head, params (K, V)[] tail) where OrdK : struct, Ord<K> =>
            LanguageExt.Map.create<OrdK, K, V>(head, tail);

        /// <summary>
        /// Create an immutable map
        /// </summary>
        [Pure]
        public static Map<OrdK, K, V> toMap<OrdK, K, V>(KeyValuePair<K, V> head, params KeyValuePair<K, V>[] tail) where OrdK : struct, Ord<K> =>
            LanguageExt.Map.create<OrdK, K, V>(head, tail);

        /// <summary>
        /// Create an immutable map
        /// </summary>
        [Pure]
        public static Map<OrdK, K, V> toMap<OrdK, K, V>(IEnumerable<(K, V)> items) where OrdK : struct, Ord<K> =>
            LanguageExt.Map.createRange<OrdK, K, V>(items);

        /// <summary>
        /// Create an immutable map
        /// </summary>
        [Pure]
        public static Map<OrdK, K, V> toMap<OrdK, K, V>(IEnumerable<Tuple<K, V>> items) where OrdK : struct, Ord<K> =>
            LanguageExt.Map.createRange<OrdK, K, V>(items);

        /// <summary>
        /// Create an immutable map
        /// </summary>
        [Pure]
        public static Map<OrdK, K, V> toMap<OrdK, K, V>(IEnumerable<KeyValuePair<K, V>> items) where OrdK : struct, Ord<K> =>
            LanguageExt.Map.createRange<OrdK, K, V>(items);



        /// <summary>
        /// Create an immutable hash-map
        /// </summary>
        [Pure]
        public static HashMap<K, V> HashMap<K, V>() =>
            LanguageExt.HashMap.empty<K, V>();

        /// <summary>
        /// Create an immutable hash-map
        /// </summary>
        [Pure]
        public static HashMap<K, V> HashMap<K, V>(Tuple<K,V> head, params Tuple<K, V>[] tail) =>
            LanguageExt.HashMap.create(head, tail);

        /// <summary>
        /// Create an immutable hash-map
        /// </summary>
        [Pure]
        public static HashMap<K, V> HashMap<K, V>((K, V) head, params (K, V)[] tail) =>
            LanguageExt.HashMap.create(head, tail);

        /// <summary>
        /// Create an immutable hash-map
        /// </summary>
        [Pure]
        public static HashMap<K, V> HashMap<K, V>(KeyValuePair<K, V> head, params KeyValuePair<K, V>[] tail) =>
            LanguageExt.HashMap.create(head, tail);

        /// <summary>
        /// Create an immutable hash-map
        /// </summary>
        [Pure]
        public static HashMap<K, V> toHashMap<K, V>(IEnumerable<(K, V)> items) =>
            LanguageExt.HashMap.createRange(items);

        /// <summary>
        /// Create an immutable hash-map
        /// </summary>
        [Pure]
        public static HashMap<K, V> toHashMap<K, V>(IEnumerable<Tuple<K, V>> items) =>
            LanguageExt.HashMap.createRange(items);

        /// <summary>
        /// Create an immutable hash-map
        /// </summary>
        [Pure]
        public static HashMap<K, V> toHashMap<K, V>(IEnumerable<KeyValuePair<K, V>> items) =>
            LanguageExt.HashMap.createRange(items);



        /// <summary>
        /// Create an immutable hash-map
        /// </summary>
        [Pure]
        public static HashMap<EqK, K, V> HashMap<EqK, K, V>() where EqK : struct, Eq<K> =>
            LanguageExt.HashMap.empty<EqK, K, V>();

        /// <summary>
        /// Create an immutable hash-map
        /// </summary>
        [Pure]
        public static HashMap<EqK, K, V> HashMap<EqK, K, V>(Tuple<K, V> head, params Tuple<K, V>[] tail) where EqK : struct, Eq<K> =>
            LanguageExt.HashMap.create<EqK, K, V>(head, tail);

        /// <summary>
        /// Create an immutable hash-map
        /// </summary>
        [Pure]
        public static HashMap<EqK, K, V> HashMap<EqK, K, V>((K, V) head, params (K, V)[] tail) where EqK : struct, Eq<K> =>
            LanguageExt.HashMap.create<EqK, K, V>(head, tail);

        /// <summary>
        /// Create an immutable hash-map
        /// </summary>
        [Pure]
        public static HashMap<EqK, K, V> HashMap<EqK, K, V>(KeyValuePair<K, V> head, params KeyValuePair<K, V>[] tail) where EqK : struct, Eq<K> =>
            LanguageExt.HashMap.create<EqK, K, V>(head, tail);

        /// <summary>
        /// Create an immutable hash-map
        /// </summary>
        [Pure]
        public static HashMap<EqK, K, V> toHashMap<EqK, K, V>(IEnumerable<Tuple<K, V>> items) where EqK : struct, Eq<K> =>
            LanguageExt.HashMap.createRange<EqK, K, V>(items);

        /// <summary>
        /// Create an immutable hash-map
        /// </summary>
        [Pure]
        public static HashMap<EqK, K, V> toHashMap<EqK, K, V>(IEnumerable<(K, V)> items) where EqK : struct, Eq<K> =>
            LanguageExt.HashMap.createRange<EqK, K, V>(items);

        /// <summary>
        /// Create an immutable hash-map
        /// </summary>
        [Pure]
        public static HashMap<EqK, K, V> toHashMap<EqK, K, V>(IEnumerable<KeyValuePair<K, V>> items) where EqK : struct, Eq<K> =>
            LanguageExt.HashMap.createRange<EqK, K, V>(items);




        /// <summary>
        /// Create an immutable list
        /// </summary>
        [Pure]
        public static Lst<T> List<T>() =>
            Lst<T>.Empty;

        /// <summary>
        /// Create an immutable list
        /// </summary>
        [Pure]
        public static Lst<T> List<T>(T x, params T[] xs) =>
            new Lst<T>(x.Cons(xs));

        /// <summary>
        /// Create an immutable list
        /// </summary>
        [Pure]
        public static Lst<T> toList<T>(Arr<T> items) =>
            new Lst<T>(items.Value);

        /// <summary>
        /// Create an immutable list
        /// </summary>
        [Pure]
        public static Lst<T> toList<T>(IEnumerable<T> items) =>
            items is Lst<T>
                ? (Lst<T>)items
                : new Lst<T>(items);



        /// <summary>
        /// Create an immutable list
        /// </summary>
        [Pure]
        public static Lst<PredList, T> List<PredList, T>() where PredList : struct, Pred<ListInfo> =>
            new Lst<PredList, T>(new T[0]);

        /// <summary>
        /// Create an immutable list
        /// </summary>
        [Pure]
        public static Lst<PredList, T> List<PredList, T>(T x, params T[] xs) where PredList : struct, Pred<ListInfo> =>
            new Lst<PredList, T>(x.Cons(xs));

        /// <summary>
        /// Create an immutable list
        /// </summary>
        [Pure]
        public static Lst<PredList, T> toList<PredList, T>(Arr<T> items) where PredList : struct, Pred<ListInfo> =>
            new Lst<PredList, T>(items.Value);

        /// <summary>
        /// Create an immutable list
        /// </summary>
        [Pure]
        public static Lst<PredList, T> toList<PredList, T>(IEnumerable<T> items) where PredList : struct, Pred<ListInfo> =>
            items is Lst<PredList, T>
                ? (Lst<PredList, T>)items
                : new Lst<PredList, T>(items);

        

        /// <summary>
        /// Create an immutable list
        /// </summary>
        [Pure]
        public static Lst<PredList, PredItem, T> List<PredList, PredItem, T>() 
            where PredItem : struct, Pred<T>
            where PredList : struct, Pred<ListInfo>  =>
            new Lst<PredList, PredItem, T>(new T[0]);

        /// <summary>
        /// Create an immutable list
        /// </summary>
        [Pure]
        public static Lst<PredList, PredItem, T> List<PredList, PredItem, T>(T x, params T[] xs) 
            where PredItem : struct, Pred<T>
            where PredList : struct, Pred<ListInfo>  =>
            new Lst<PredList, PredItem, T>(x.Cons(xs));

        /// <summary>
        /// Create an immutable list
        /// </summary>
        [Pure]
        public static Lst<PredList, PredItem, T> toList<PredList, PredItem, T>(Arr<T> items) 
            where PredItem : struct, Pred<T>
            where PredList : struct, Pred<ListInfo>  =>
            new Lst<PredList, PredItem, T>(items.Value);

        /// <summary>
        /// Create an immutable list
        /// </summary>
        [Pure]
        public static Lst<PredList, PredItem, T> toList<PredList, PredItem, T>(IEnumerable<T> items) 
            where PredItem : struct, Pred<T>
            where PredList : struct, Pred<ListInfo>  =>
            items is Lst<PredList, PredItem, T>
                ? (Lst<PredList, PredItem, T>)items
                : new Lst<PredList, PredItem, T>(items);




        /// <summary>
        /// Create an immutable queue
        /// </summary>
        [Pure]
        public static Arr<T> Array<T>() =>
            Arr<T>.Empty;

        /// <summary>
        /// Create an immutable queue
        /// </summary>
        [Pure]
        public static Arr<T> Array<T>(T x, params T[] xs) =>
            new Arr<T>(x.Cons(xs).ToArray());

        /// <summary>
        /// Create an immutable queue
        /// </summary>
        [Pure]
        public static Arr<T> toArray<T>(IEnumerable<T> items) =>
            new Arr<T>(items);

        /// <summary>
        /// Create an immutable queue
        /// </summary>
        [Pure]
        public static Que<T> Queue<T>() =>
            Que<T>.Empty;

        /// <summary>
        /// Create an immutable queue
        /// </summary>
        [Pure]
        public static Que<T> Queue<T>(params T[] items)
        {
            var q = new QueInternal<T>();
            foreach (var item in items)
            {
                q = q.Enqueue(item);
            }
            return new Que<T>(q);
        }

        /// <summary>
        /// Create an immutable queue
        /// </summary>
        [Pure]
        public static Que<T> toQueue<T>(IEnumerable<T> items)
        {
            var q = new QueInternal<T>();
            foreach (var item in items)
            {
                q = q.Enqueue(item);
            }
            return new Que<T>(q);
        }

        /// <summary>
        /// Create an immutable stack
        /// </summary>
        [Pure]
        public static Stck<T> Stack<T>() =>
            new Stck<T>();

        /// <summary>
        /// Create an immutable stack
        /// </summary>
        [Pure]
        public static Stck<T> Stack<T>(params T[] items) =>
            new Stck<T>(items);

        /// <summary>
        /// Create an immutable stack
        /// </summary>
        [Pure]
        public static Stck<T> toStack<T>(IEnumerable<T> items) =>
            new Stck<T>(items);




        /// <summary>
        /// Create an immutable set
        /// </summary>
        [Pure]
        public static Set<T> Set<T>() =>
            LanguageExt.Set.create<T>();

        /// <summary>
        /// Create an immutable set
        /// </summary>
        [Pure]
        public static Set<T> Set<T>(T head, params T[] tail) =>
            LanguageExt.Set.createRange(head.Cons(tail));

        /// <summary>
        /// Create an immutable set
        /// </summary>
        [Pure]
        public static Set<T> toSet<T>(IEnumerable<T> items) =>
            LanguageExt.Set.createRange(items);



        /// <summary>
        /// Create an immutable set
        /// </summary>
        [Pure]
        public static Set<OrdT, T> Set<OrdT, T>() where OrdT : struct, Ord<T> =>
            LanguageExt.Set.create<OrdT, T>();

        /// <summary>
        /// Create an immutable set
        /// </summary>
        [Pure]
        public static Set<OrdT, T> Set<OrdT, T>(T head, params T[] tail) where OrdT : struct, Ord<T> =>
            LanguageExt.Set.createRange<OrdT, T>(head.Cons(tail));

        /// <summary>
        /// Create an immutable set
        /// </summary>
        [Pure]
        public static Set<OrdT, T> toSet<OrdT, T>(IEnumerable<T> items) where OrdT : struct, Ord<T> =>
            LanguageExt.Set.createRange<OrdT, T>(items);


        /// <summary>
        /// Create an immutable hash-set
        /// </summary>
        [Pure]
        public static HashSet<T> HashSet<T>() =>
            LanguageExt.HashSet.create<T>();

        /// <summary>
        /// Create an immutable hash-set
        /// </summary>
        [Pure]
        public static HashSet<T> HashSet<T>(T head, params T[] tail) =>
            LanguageExt.HashSet.createRange(head.Cons(tail));

        /// <summary>
        /// Create an immutable hash-set
        /// </summary>
        [Pure]
        public static HashSet<T> toHashSet<T>(IEnumerable<T> items) =>
            LanguageExt.HashSet.createRange(items);





        /// <summary>
        /// Create an immutable hash-set
        /// </summary>
        [Pure]
        public static HashSet<EqT, T> HashSet<EqT, T>() where EqT : struct, Eq<T> =>
            LanguageExt.HashSet.create<EqT, T>();

        /// <summary>
        /// Create an immutable hash-set
        /// </summary>
        [Pure]
        public static HashSet<EqT, T> HashSet<EqT, T>(T head, params T[] tail) where EqT : struct, Eq<T> =>
            LanguageExt.HashSet.createRange<EqT, T>(head.Cons(tail));

        /// <summary>
        /// Create an immutable hash-set
        /// </summary>
        [Pure]
        public static HashSet<EqT, T> toHashSet<EqT, T>(IEnumerable<T> items) where EqT : struct, Eq<T> =>
            LanguageExt.HashSet.createRange<EqT, T>(items);





        /// <summary>
        /// Create a queryable
        /// </summary>
        [Pure]
        public static IQueryable<T> Query<T>(params T[] items) =>
            toQuery(items);

        /// <summary>
        /// Convert to queryable
        /// </summary>
        [Pure]
        public static IQueryable<T> toQuery<T>(IEnumerable<T> items) =>
            items.AsQueryable();

        /// <summary>
        /// List matching
        /// </summary>
        [Pure]
        public static R match<T, R>(IEnumerable<T> list,
            Func<R> Empty,
            Func<T, IEnumerable<T>, R> More) =>
            list.Match(Empty, More);

        /// <summary>
        /// List matching
        /// </summary>
        [Pure]
        public static R match<T, R>(IEnumerable<T> list,
            Func<R> Empty,
            Func<T, R> One,
            Func<T, IEnumerable<T>, R> More ) =>
            list.Match(Empty, One, More);

        /// <summary>
        /// List matching
        /// </summary>
        [Pure]
        public static R match<T, R>(IEnumerable<T> list,
            Func<R> Empty,
            Func<T, R> One,
            Func<T, T, R> Two,
            Func<T, T, IEnumerable<T>, R> More) =>
            list.Match(Empty, One, Two, More);

        /// <summary>
        /// List matching
        /// </summary>
        [Pure]
        public static R match<T, R>(IEnumerable<T> list,
            Func<R> Empty,
            Func<T, R> One,
            Func<T, T, R> Two,
            Func<T, T, T, R> Three,
            Func<T, T, T, IEnumerable<T>, R> More) =>
            list.Match(Empty, One, Two, Three, More);

        /// <summary>
        /// List matching
        /// </summary>
        [Pure]
        public static R match<T, R>(IEnumerable<T> list,
            Func<R> Empty,
            Func<T, R> One,
            Func<T, T, R> Two,
            Func<T, T, T, R> Three,
            Func<T, T, T, T, R> Four,
            Func<T, T, T, T, IEnumerable<T>, R> More) =>
            list.Match(Empty, One, Two, Three, Four, More);

        /// <summary>
        /// List matching
        /// </summary>
        [Pure]
        public static R match<T, R>(IEnumerable<T> list,
            Func<R> Empty,
            Func<T, R> One,
            Func<T, T, R> Two,
            Func<T, T, T, R> Three,
            Func<T, T, T, T, R> Four,
            Func<T, T, T, T, T, R> Five,
            Func<T, T, T, T, T, IEnumerable<T>, R> More) =>
            list.Match(Empty, One, Two, Three, Four, Five, More);

        /// <summary>
        /// List matching
        /// </summary>
        [Pure]
        public static R match<T, R>(IEnumerable<T> list,
            Func<R> Empty,
            Func<T, R> One,
            Func<T, T, R> Two,
            Func<T, T, T, R> Three,
            Func<T, T, T, T, R> Four,
            Func<T, T, T, T, T, R> Five,
            Func<T, T, T, T, T, T, R> Six,
            Func<T, T, T, T, T, T, IEnumerable<T>, R> More) =>
            list.Match(Empty, One, Two, Three, Four, Five, Six, More);

        [Pure]
        public static R match<K, V, R>(Map<K, V> map, K key, Func<V, R> Some, Func<R> None) =>
            match(LanguageExt.Map.find(map, key),
                   Some,
                   None );

        public static Unit match<K, V>(Map<K, V> map, K key, Action<V> Some, Action None) =>
            match(LanguageExt.Map.find(map, key),
                   Some,
                   None);

        [Pure]
        public static R match<K, V, R>(HashMap<K, V> map, K key, Func<V, R> Some, Func<R> None) =>
            match(LanguageExt.HashMap.find(map, key),
                   Some,
                   None);

        public static Unit match<K, V>(HashMap<K, V> map, K key, Action<V> Some, Action None) =>
            match(LanguageExt.HashMap.find(map, key),
                   Some,
                   None);

        /// <summary>
        /// Convert any value to an enumerable
        ///     T     : [x]
        ///     null  : []
        /// </summary>
        [Pure]
        public static IEnumerable<T> seqOne<T>(T value) =>
            value.IsNull() ? new T[0] : new T[1] { value };

        /// <summary>
        /// Convert a nullable to an enumerable
        ///     HasValue == true  : [x]
        ///     HasValue == false : []
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(T? value) where T : struct =>
            value.AsEnumerable();

        /// <summary>
        /// Convert an Enumerable to an Enumerable
        /// Deals with `value == null` by returning `[]`
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(IEnumerable<T> value) =>
            value?.AsEnumerable() ?? new T[0];

        /// <summary>
        /// Convert an option to an enumerable
        ///     Some(x) : [x]
        ///     None    : []
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(Option<T> value) =>
            value.AsEnumerable();

        /// <summary>
        /// Convert an option to an enumerable
        ///     Some(x) : [x]
        ///     None    : []
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(OptionUnsafe<T> value) =>
            value.AsEnumerable();

        /// <summary>
        /// Convert an either to an enumerable
        ///     Right(x) : [x]
        ///     Left(y)  : []
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<L, T>(Either<L, T> value) =>
            value.RightAsEnumerable();

        /// <summary>
        /// Convert an either to an enumerable
        ///     Right(x) : [x]
        ///     Left(y)  : []
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<L, T>(EitherUnsafe<L, T> value) =>
            value.RightAsEnumerable();

        /// <summary>
        /// Convert a Try to an enumerable
        ///     Succ(x) : [x]
        ///     Fail(e) : []
        ///     null    : []
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(Try<T> value) =>
            value?.AsEnumerable() ?? new T[0];

        /// <summary>
        /// Convert a TryOption to an enumerable
        ///     Succ(x) : [x]
        ///     Fail(e) : []
        ///     None    : []
        ///     null    : []
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(TryOption<T> value) =>
            value?.AsEnumerable() ?? new T[0];

        /// <summary>
        /// Convert a TryOption to an enumerable
        ///     Succ(x) : [x]
        ///     Fail(e) : []
        ///     None    : []
        ///     null    : []
        /// </summary>
        [Pure]
        public static Task<IEnumerable<T>> seq<T>(TryAsync<T> value) =>
            value?.AsEnumerable() ?? Task.FromResult(new T[0].AsEnumerable());

        /// <summary>
        /// Convert a TryOption to an enumerable
        ///     Succ(x) : [x]
        ///     Fail(e) : []
        ///     None    : []
        ///     null    : []
        /// </summary>
        [Pure]
        public static Task<IEnumerable<T>> seq<T>(TryOptionAsync<T> value) =>
            value?.AsEnumerable() ?? Task.FromResult(new T[0].AsEnumerable());

        /// <summary>
        /// Convert a tuple to an enumerable
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(Tuple<T> tup) =>
            tup == null
                ? new T[0]
                : new[] { tup.Item1 };

        /// <summary>
        /// Convert a tuple to an enumerable
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(Tuple<T, T> tup) =>
            tup == null
                ? new T[0]
                : new[] { tup.Item1, tup.Item2 };

        /// <summary>
        /// Convert a tuple to an enumerable
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(Tuple<T, T, T> tup) =>
            tup == null
                ? new T[0]
                : new[] { tup.Item1, tup.Item2, tup.Item3 };

        /// <summary>
        /// Convert a tuple to an enumerable
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(Tuple<T, T, T, T> tup) =>
            tup == null
                ? new T[0]
                : new[] { tup.Item1, tup.Item2, tup.Item3, tup.Item4 };

        /// <summary>
        /// Convert a tuple to an enumerable
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(Tuple<T, T, T, T, T> tup) =>
            tup == null
                ? new T[0]
                : new[] { tup.Item1, tup.Item2, tup.Item3, tup.Item4, tup.Item5 };

        /// <summary>
        /// Convert a tuple to an enumerable
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(Tuple<T, T, T, T, T, T> tup) =>
            tup == null
                ? new T[0]
                : new[] { tup.Item1, tup.Item2, tup.Item3, tup.Item4, tup.Item5, tup.Item6 };

        /// <summary>
        /// Convert a tuple to an enumerable
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(Tuple<T, T, T, T, T, T, T> tup) =>
            tup == null
                ? new T[0]
                : new[] { tup.Item1, tup.Item2, tup.Item3, tup.Item4, tup.Item5, tup.Item6, tup.Item7 };

        /// <summary>
        /// Convert a tuple to an enumerable
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(ValueTuple<T, T> tup) =>
            new[] { tup.Item1, tup.Item2 };

        /// <summary>
        /// Convert a tuple to an enumerable
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(ValueTuple<T, T, T> tup) =>
            new[] { tup.Item1, tup.Item2, tup.Item3 };

        /// <summary>
        /// Convert a tuple to an enumerable
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(ValueTuple<T, T, T, T> tup) =>
            new[] { tup.Item1, tup.Item2, tup.Item3, tup.Item4 };

        /// <summary>
        /// Convert a tuple to an enumerable
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(ValueTuple<T, T, T, T, T> tup) =>
            new[] { tup.Item1, tup.Item2, tup.Item3, tup.Item4, tup.Item5 };

        /// <summary>
        /// Convert a tuple to an enumerable
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(ValueTuple<T, T, T, T, T, T> tup) =>
            new[] { tup.Item1, tup.Item2, tup.Item3, tup.Item4, tup.Item5, tup.Item6 };

        /// <summary>
        /// Convert a tuple to an enumerable
        /// </summary>
        [Pure]
        public static IEnumerable<T> seq<T>(ValueTuple<T, T, T, T, T, T, T> tup) =>
            new[] { tup.Item1, tup.Item2, tup.Item3, tup.Item4, tup.Item5, tup.Item6, tup.Item7 };
    }
}

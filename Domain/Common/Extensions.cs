﻿namespace Domain.Common;

public static class Extensions
{
	public static bool Like(this string source, string comparison) =>
		string.Equals(source.Trim(), comparison.Trim(), StringComparison.InvariantCultureIgnoreCase);

	public static bool Embeds(this string source, string smallerString) =>
		source.Contains(smallerString.Trim(), StringComparison.InvariantCultureIgnoreCase);

	public static bool In(this string source, params string[] list) =>
		list.Any(item => source.Like(item));

	public static bool In(this string source, IEnumerable<string> list) =>
		list.Any(item => source.Like(item));

	public static bool In<T>(this T source, params T[] list) =>
		list.Contains(source);

	public static bool Has(this IEnumerable<string> source, string item) =>
		item.In(source);

	public static bool HasInk(this string source) =>
		!string.IsNullOrWhiteSpace(source);

	public static string Join(this IEnumerable<string> source, string separator) =>
		string.Join(separator, source);

	public static string Join<T>(this IEnumerable<T> source, string separator) where T : Enum =>
		source.Select(s => s.ToString())
			.Join(separator);
}

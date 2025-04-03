// Generated by Sichem at 12/24/2021 8:28:15 PM

using Hebron.Runtime;

namespace StbImageSharp;

internal unsafe partial class StbImage
{
	public static int stbi__hdr_test(stbi__context s)
	{
		var r = stbi__hdr_test_core(s, "#?RADIANCE\n");
		stbi__rewind(s);
		if (r == 0)
		{
			r = stbi__hdr_test_core(s, "#?RGBE\n");
			stbi__rewind(s);
		}

		return r;
	}

	public static float* stbi__hdr_load(stbi__context s, int* x, int* y, int* comp, int req_comp,
		stbi__result_info* ri)
	{
		var rgbe = stackalloc byte[4];
		var buffer = stackalloc sbyte[1024];
		sbyte* token;
		var valid = 0;
		var i = 0;
		var j = 0;
		var z = 0;
		var headerToken = stbi__hdr_gettoken(s, buffer);
		if (CRuntime.strcmp(headerToken, "#?RADIANCE") != 0 && CRuntime.strcmp(headerToken, "#?RGBE") != 0)
			return (float*)(ulong)(stbi__err("not HDR") != 0 ? 0 : 0);
		for (; ; )
		{
			token = stbi__hdr_gettoken(s, buffer);
			if (token[0] == 0)
				break;
			if (CRuntime.strcmp(token, "FORMAT=32-bit_rle_rgbe") == 0)
				valid = 1;
		}

		if (valid == 0)
			return (float*)(ulong)(stbi__err("unsupported format") != 0 ? 0 : 0);
		token = stbi__hdr_gettoken(s, buffer);
		if (CRuntime.strncmp(token, "-Y ", 3) != 0)
			return (float*)(ulong)(stbi__err("unsupported data layout") != 0 ? 0 : 0);
		token += 3;
		var height = (int)CRuntime.strtol(token, &token, 10);
		while (*token == 32)
			++token;
		if (CRuntime.strncmp(token, "+X ", 3) != 0)
			return (float*)(ulong)(stbi__err("unsupported data layout") != 0 ? 0 : 0);
		token += 3;
		var width = (int)CRuntime.strtol(token, null, 10);
		if (height > 1 << 24)
			return (float*)(ulong)(stbi__err("too large") != 0 ? 0 : 0);
		if (width > 1 << 24)
			return (float*)(ulong)(stbi__err("too large") != 0 ? 0 : 0);
		*x = width;
		*y = height;
		if (comp != null)
			*comp = 3;
		if (req_comp == 0)
			req_comp = 3;
		if (stbi__mad4sizes_valid(width, height, req_comp, sizeof(float), 0) == 0)
			return (float*)(ulong)(stbi__err("too large") != 0 ? 0 : 0);
		var hdr_data = (float*)stbi__malloc_mad4(width, height, req_comp, sizeof(float), 0);
		if (hdr_data == null)
			return (float*)(ulong)(stbi__err("outofmem") != 0 ? 0 : 0);

		if (width < 8 || width >= 32768)
		{
			for (; j < height; ++j)
			{
				for (; i < width; ++i)
				{
					//var rgbe = stackalloc byte[4];
					stbi__getn(s, rgbe, 4);
					stbi__hdr_convert(hdr_data + j * width * req_comp + i * req_comp, rgbe, req_comp);
				}
			}
		}
		else
		{
			byte* scanline = null;
			for (j = 0; j < height; ++j)
			{
				var c1 = stbi__get8(s);
				var c2 = stbi__get8(s);
				var len = stbi__get8(s);
				if (c1 != 2 || c2 != 2 || (len & 0x80) != 0)
				{
					//var rgbe = stackalloc byte[4];
					rgbe[0] = (byte)c1;
					rgbe[1] = (byte)c2;
					rgbe[2] = (byte)len;
					rgbe[3] = stbi__get8(s);
					stbi__hdr_convert(hdr_data, rgbe, req_comp);
					CRuntime.free(scanline);

					// goto main_decode_loop

					// Do first row
					j = 0;
					for (i = 1; i < width; ++i)
					{
						//var rgbe = stackalloc byte[4];
						stbi__getn(s, rgbe, 4);
						stbi__hdr_convert(hdr_data + j * width * req_comp + i * req_comp, rgbe, req_comp);
					}

					// Do the rest of the rows.
					for (j = 1; j < height; ++j)
					{
						for (i = 0; i < width; ++i)
						{
							//var rgbe = stackalloc byte[4];
							stbi__getn(s, rgbe, 4);
							stbi__hdr_convert(hdr_data + j * width * req_comp + i * req_comp, rgbe, req_comp);
						}
					}

					goto finish;
				}

				len <<= 8;
				len |= stbi__get8(s);
				if (len != width)
				{
					CRuntime.free(hdr_data);
					CRuntime.free(scanline);
					return (float*)(ulong)(stbi__err("invalid decoded scanline length") != 0 ? 0 : 0);
				}

				if (scanline == null)
				{
					scanline = (byte*)stbi__malloc_mad2(width, 4, 0);
					if (scanline == null)
					{
						CRuntime.free(hdr_data);
						return (float*)(ulong)(stbi__err("outofmem") != 0 ? 0 : 0);
					}
				}

				for (var k = 0; k < 4; ++k)
				{
					var nleft = 0;
					i = 0;
					while ((nleft = width - i) > 0)
					{
						var count = stbi__get8(s);
						if (count > 128)
						{
							var value = stbi__get8(s);
							count -= 128;
							if (count == 0 || count > nleft)
							{
								CRuntime.free(hdr_data);
								CRuntime.free(scanline);
								return (float*)(ulong)(stbi__err("corrupt") != 0 ? 0 : 0);
							}

							for (z = 0; z < count; ++z)
								scanline[i++ * 4 + k] = value;
						}
						else
						{
							if (count == 0 || count > nleft)
							{
								CRuntime.free(hdr_data);
								CRuntime.free(scanline);
								return (float*)(ulong)(stbi__err("corrupt") != 0 ? 0 : 0);
							}

							for (z = 0; z < count; ++z)
								scanline[i++ * 4 + k] = stbi__get8(s);
						}
					}
				}

				for (i = 0; i < width; ++i)
					stbi__hdr_convert(hdr_data + (j * width + i) * req_comp, scanline + i * 4, req_comp);
			}

			if (scanline != null)
				CRuntime.free(scanline);
		}

		finish:
		return hdr_data;
	}

	public static int stbi__hdr_info(stbi__context s, int* x, int* y, int* comp)
	{
		var buffer = stackalloc sbyte[1024];
		sbyte* token;
		var valid = 0;
		var dummy = 0;
		if (x == null)
			x = &dummy;
		if (y == null)
			y = &dummy;
		if (comp == null)
			comp = &dummy;
		if (stbi__hdr_test(s) == 0)
		{
			stbi__rewind(s);
			return 0;
		}

		for (; ; )
		{
			token = stbi__hdr_gettoken(s, buffer);
			if (token[0] == 0)
				break;
			if (CRuntime.strcmp(token, "FORMAT=32-bit_rle_rgbe") == 0)
				valid = 1;
		}

		if (valid == 0)
		{
			stbi__rewind(s);
			return 0;
		}

		token = stbi__hdr_gettoken(s, buffer);
		if (CRuntime.strncmp(token, "-Y ", 3) != 0)
		{
			stbi__rewind(s);
			return 0;
		}

		token += 3;
		*y = (int)CRuntime.strtol(token, &token, 10);
		while (*token == 32)
			++token;
		if (CRuntime.strncmp(token, "+X ", 3) != 0)
		{
			stbi__rewind(s);
			return 0;
		}

		token += 3;
		*x = (int)CRuntime.strtol(token, null, 10);
		*comp = 3;
		return 1;
	}

	public static byte* stbi__hdr_to_ldr(float* data, int x, int y, int comp)
	{
		var k = 0;
		var n = 0;
		if (data == null)
			return null;
		var output = (byte*)stbi__malloc_mad3(x, y, comp, 0);
		if (output == null)
		{
			CRuntime.free(data);
			return (byte*)(ulong)(stbi__err("outofmem") != 0 ? 0 : 0);
		}

		if ((comp & 1) != 0)
			n = comp;
		else
			n = comp - 1;
		for (var i = 0; i < x * y; ++i)
		{
			for (k = 0; k < n; ++k)
			{
				var z = (float)CRuntime.pow(data[i * comp + k] * stbi__h2l_scale_i, stbi__h2l_gamma_i) * 255 +
					0.5f;
				if (z < 0)
					z = 0;
				if (z > 255)
					z = 255;
				output[i * comp + k] = (byte)(int)z;
			}

			if (k < comp)
			{
				var z = data[i * comp + k] * 255 + 0.5f;
				if (z < 0)
					z = 0;
				if (z > 255)
					z = 255;
				output[i * comp + k] = (byte)(int)z;
			}
		}

		CRuntime.free(data);
		return output;
	}

	public static int stbi__hdr_test_core(stbi__context s, string signature)
	{
		for (var i = 0; i < signature.Length; ++i)
			if (stbi__get8(s) != signature[i])
				return 0;
		stbi__rewind(s);
		return 1;
	}

	public static sbyte* stbi__hdr_gettoken(stbi__context z, sbyte* buffer)
	{
		var len = 0;
		var c = (sbyte)stbi__get8(z);
		while (stbi__at_eof(z) == 0 && c != 10)
		{
			buffer[len++] = c;
			if (len == 1024 - 1)
			{
				while (stbi__at_eof(z) == 0 && stbi__get8(z) != 10)
				{
				}

				break;
			}

			c = (sbyte)stbi__get8(z);
		}

		buffer[len] = 0;
		return buffer;
	}

	public static void stbi__hdr_convert(float* output, byte* input, int req_comp)
	{
		if (input[3] != 0)
		{
			var f1 = (float)CRuntime.ldexp(1.0f, input[3] - (128 + 8));
			if (req_comp <= 2)
			{
				output[0] = (input[0] + input[1] + input[2]) * f1 / 3;
			}
			else
			{
				output[0] = input[0] * f1;
				output[1] = input[1] * f1;
				output[2] = input[2] * f1;
			}

			if (req_comp == 2)
				output[1] = 1;
			if (req_comp == 4)
				output[3] = 1;
		}
		else
		{
			switch (req_comp)
			{
				case 4:
				case 3:
					if (req_comp == 4)
						output[3] = 1;
					output[0] = output[1] = output[2] = 0;
					break;
				case 2:
				case 1:
					if (req_comp == 2)
						output[1] = 1;
					output[0] = 0;
					break;
			}
		}
	}
}
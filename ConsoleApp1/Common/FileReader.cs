using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Common;
public class FileReader
{
    private readonly string path;

	public FileReader(string path)
	{
		this.path = path;
	}

	public string[] ReadLines()
	{
		return File.ReadAllLines(path);
	}

}

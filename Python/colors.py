#!/usr/bin/python

import wikipedia
import re
import string
import struct
from pprint import pprint

colors_page = wikipedia.page("List_of_colors_(compact)")
html = colors_page.html()
colors = {}
for color in re.findall('<p title=.*?#+(.*?)\" style=\"[\s\S]*?\" title=\".+\">(.+?)</a>', html):
	name = re.sub('[\W_]+', '', color[1].title())
	if name in colors:
		name = name + '2'
	r,g,b = struct.unpack('BBB',color[0].decode('hex'))
	colors[name] = "\tpublic static readonly Color %s = new Color(%0.3ff, %0.3ff, %0.3ff, 1f);" % (name, r/255.0, g/255.0, b/255.0)

print "public static class Colors {"
for key,value in sorted(colors.items()):
	print value
print "}"
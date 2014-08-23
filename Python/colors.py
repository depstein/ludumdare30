#!/usr/bin/python

import wikipedia
import re
import string
from pprint import pprint

colors_page = wikipedia.page("List_of_colors_(compact)")
html = colors_page.html()
colors = {}
for color in re.findall('<p title=.*?#(.*?)\" style=\"[\s\S]*?\" title=\".+\">(.+?)</a>', html):
	name = re.sub('[\W_]+', '', color[1].title())
	if name in colors:
		name = name + '2'
	colors[name] = "\tpublic const string %s = \"#%s\";" % (name, color[0])

print "public class Colors {"
for key,value in sorted(colors.items()):
	print value
print "}"
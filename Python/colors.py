#!/usr/bin/python

import wikipedia
import re
import string
from pprint import pprint

colors = wikipedia.page("List_of_colors_(compact)")
html = colors.html()
for color in re.findall('<p title=.*?#(.*?)\" style=\"[\s\S]*?\" title=\".+\">(.+?)</a>', html):
	print "public const string %s = \"#%s\";" % (re.sub('[\W_]+', '', color[1].title()), color[0])
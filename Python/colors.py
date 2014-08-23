#!/usr/bin/python

import wikipedia
import re
import string
from pprint import pprint

colors = wikipedia.page("List_of_colors_(compact)")
html = colors.html()
print "Dictionary<string,string> colors = new Dictionary<string,string>() {"
for color in re.findall('<p title=.*?#(.*?)\" style=\"[\s\S]*?\" title=\".+\">(.+?)</a>', html):
	print "{\"%s\",\"#%s\"}," % (re.sub('[\W_]+', '', color[1]).upper(), color[0])
print "}"
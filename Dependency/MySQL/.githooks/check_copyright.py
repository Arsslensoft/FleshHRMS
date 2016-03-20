#!c:\python27\python.exe

import re
import sys
import os
from datetime import date
 
year = str(date.today().year)
error = False

#files = os.popen("git diff --name-only --diff-filter=ACMRTUXB").read().splitlines(True)
files = os.popen("git status -uno --porcelain").read().splitlines(True)
for file in files:
  status = file[0:2].strip()
  if status == 'R':
    continue
  filename = file[2:].strip()
  
  with open(filename) as f:
    file_content = f.readlines()

  for line in file_content:  
    if line.find("Copyright") == -1:
      continue
    if line.find(year) == -1:
      print filename + ' does not have an updated copyright date'
      error = True

if error:
  sys.exit(1)

sys.exit(0)

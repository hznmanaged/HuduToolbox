# Horizon Hudu Toolbox
This is a collection of tools that were written to ease the maintenance of a Hudu instance.

# Functions
## Broken image report
Generates an HTML file listing all of the articles and assets that contains \<img> tags with sources that are inaccessible images. Must run 

## Import images
Searches for \<img> tags linking to somewhere not hosted on one of these domains:
1. The domain specified as your hudu server.
2. ^(https?\:\\/\\/)(hudu[^\\.]+.[^\\.]+\\.digitaloceanspaces\\.com\/.+)$

Only imports webp, png, and jpeg files.

## Rewrite URLs

Uses search regexes to identify and update \<a> tags.
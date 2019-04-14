from __future__ import unicode_literals
import youtube_dl
import argparse

parser = argparse.ArgumentParser()
parser.add_argument('--url', type=str)
parser.add_argument('--noplaylist', type=bool, default=False)
args = parser.parse_args()

options = {
    'verbose': True,
    'outtmpl': '../Downloaded files/Video/%(extractor_key)s/%(title)s.%(ext)s',
    'addmetadata': True,
    'format': 'best[ext=mp4]',
}

with youtube_dl.YoutubeDL(options) as ydl:
    ydl.download([args.url])

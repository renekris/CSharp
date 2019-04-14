from __future__ import unicode_literals
import youtube_dl
import argparse

parser = argparse.ArgumentParser()
parser.add_argument('--url', type=str)
parser.add_argument('--noplaylist', type=bool, default=False)
args = parser.parse_args()

options = {
    'outtmpl': 'Downloaded files/Video/%(extractor_key)s/%(title)s.%(ext)s',
    'addmetadata':True,
    'format': 'bestvideo[ext=mp4]+bestaudio[ext=m4a]',
}

with youtube_dl.YoutubeDL(options) as ydl:
    ydl.download([args.url])

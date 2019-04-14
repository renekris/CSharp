from __future__ import unicode_literals
import youtube_dl
import argparse

parser = argparse.ArgumentParser()
parser.add_argument('--url', type=str)
parser.add_argument('--noplaylist', type=bool, default=False)
args = parser.parse_args()

options = {
    
    'outtmpl': 'Downloaded files/Audio/%(extractor_key)s/%(title)s.%(ext)s',
    'format': 'bestaudio/best',
    'writethumbnail': True,
    'nocheckcertificate': True,
    'addmetadata': True,
    'noplaylist' : args.noplaylist,
    'postprocessors': [{
        'key': 'FFmpegExtractAudio',
        'preferredcodec': 'm4a',
        'preferredquality': '192',
    },
        {'key': 'EmbedThumbnail'},
        {'key': 'FFmpegMetadata'},]
}




with youtube_dl.YoutubeDL(options) as ydl:
    ydl.download([args.url])


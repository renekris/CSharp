from __future__ import unicode_literals
import youtube_dl
import argparse

parser = argparse.ArgumentParser()
parser.add_argument('--url', type=str)
args = parser.parse_args()

options = {
    'verbose': True,
    'outtmpl': '../Downloaded files/Audio/%(extractor_key)s/%(title)s.%(ext)s',
    'format': 'bestaudio',
    'nocheckcertificate': True,
    'addmetadata': True,
    'postprocessors': [{
        'key': 'FFmpegExtractAudio',
        'preferredcodec': 'mp3',
        'preferredquality': '192',
    },
        {'key': 'FFmpegMetadata'},]
}

youtube_dl.YoutubeDL(options).download([args.url])

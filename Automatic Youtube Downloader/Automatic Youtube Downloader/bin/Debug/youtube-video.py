import argparse
from pytube import YouTube

parser = argparse.ArgumentParser()
parser.add_argument('--url', type=str)
args = parser.parse_args()

YouTube(args.url).streams.first().download()

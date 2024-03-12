#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Tue Dec 12 14:32:32 2023

@author: root
"""

import cv2
import socket
from cvzone.HandTrackingModule import HandDetector


#Parameters
w, h = 1280, 720

#Webcam
cap = cv2.VideoCapture(0)
cap.set(3, w)
cap.set(4, h)

#HandDetector
detector = HandDetector(maxHands=1, detectionCon=0.8)

#Communication
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)


while True:
    #Get the frame from the webcam
    success, img = cap.read()
    
    #Get hand
    hands, img = detector.findHands(img)
    
    #Landmarks (x,y,z) * 21 (Detected points)
    
    data = []

    if hands:
        # Hand 1
        hand = hands[0]
        lmList = hand["lmList"]  # List of 21 Landmark points
        for lm in lmList:
            data.extend([lm[0], h - lm[1], lm[2]])
            
        sock.sendto(str.encode(str(data)), serverAddressPort)
    
    img = cv2.resize(img, (0, 0), None, 0.5, 0.5)
    cv2.imshow("Image", img)
    cv2.waitKey(1)
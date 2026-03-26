from microbit import *
import math


# AUSKOMMENTIEREN
compass.calibrate()
# das ist der target winkel 

# Pfeile als LED-Muster
arrows = {
    "N":  Image("00900:09090:90009:00900:00900"),  # ↑ passt
    "NE": Image("00999:00009:00909:09000:90000"),  # ↗ passt
    "E":  Image("00900:00090:99999:00090:00900"),  # → passt 
    "SE": Image("90000:09000:00909:00009:00999"),  # ↘ passt
    "S":  Image("00900:00900:90009:09090:00900"),  # ↓ passt
    "SW": Image("00009:00090:90900:90000:99900"),  # ↙ passt
    "W":  Image("00900:09000:99999:09000:00900"),  # ← passt
    "NW": Image("99900:90000:90900:00090:00009"),  # ↖
}

def immer_an_einen_punkt_zeigen(grad_wo_zu_punkt_zeigt):
    absolute_grad = compass.heading()

    relativ_grad = (grad_wo_zu_punkt_zeigt - absolute_grad) % 360

    if relativ_grad < 22.5 or relativ_grad >= 337.5:
        return "N"
    elif relativ_grad < 67.5:
        return "NE"
    elif relativ_grad < 112.5:
        return "E"
    elif relativ_grad < 157.5:
        return "SE"
    elif relativ_grad < 202.5:
        return "S"
    elif relativ_grad < 247.5:
        return "SW"
    elif relativ_grad < 292.5:
        return "W"
    else:
        return "NW"

winkel_zu_punkt = 0

while True:
    if uart.any():
        try:
            raw = uart.readline()
            if raw:  # sicherstellen dass es nicht None ist
                data = raw.decode("utf-8").strip()
                winkel_zu_punkt = int(data)
        except:
            pass

            
    grad = compass.heading()
    direction = immer_an_einen_punkt_zeigen(winkel_zu_punkt)
    
    display.show(arrows[direction])
    
    
    
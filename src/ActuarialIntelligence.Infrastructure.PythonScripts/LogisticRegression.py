import numpy as np
from matplotlib import pyplot as plt
from sklearn.linear_model import LogisticRegression
x = np.array([[0],[0.3],[0.6],[0.8],[1]])
y = np.array([0,0,1,1,1])
model = LogisticRegression()
model.fit(x,y)
print("Intercept",model.intercept_)
pred = model.predict_proba(x)[:,1]
print("Prediction",pred)
print("Pred1",pred[0])

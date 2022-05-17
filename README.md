# Space War
Name: Zijing Mu

Student Number: D17129502

Class Group: TU856

# Description of the project
This will be a 3D project showing a combat between space fleets of two planets. Space ships with various steering behaviours will be implemented in the project. Inspiration is from a cg from starcraft2. 
# Story
2 squads of guards ships are escorting the supply ship. they fly on a given route. however an enemy squad undercover them for a long time. they find a chance to attack supply ships and guard ships from the left. Guard ships and enemy ships are in a tangle fight. the guard ships gradually lost the fight and start to cover the supply ship to flee. character reach the battlefield to help them.
# video

# scene summary
1. view to see the forward of the fleet consists of a supply ship and several guard ships
2. view of one of the guard ship leaders and looking at the supply ship.
3. enemy squad move to the fleet
4. enemy fight with guards
5. call the main character for help
6. view of one of the guard ships and supply flees
7. main character starts space wrap and reach the battle field.
# behaviours
1. pathfollow
2. flee
3. pursue
4. obstacle avoidance
5. attack
6. offset pursue
# FSM
1. followingLeader: use offset pursue to make ships move as a squad
2. find station: guard ships will find the supply ship.
3. flee and find supply ship when the distance to supply ship is too long
4. attack and flee when the distance is small
5. pursue and attack when in range
# additional scripts except for the scripts from the lab
1. shipstates: contains all states and transistion conditions.
2. shipcontroller: space station, guards and enemy ship controller
3. 2 * charactermovement: control the way of main character movement
4. teleportcharacter: controls the teleport and space wrap end point
# additional implementation
1. rewrite the states to fit the requirements
2. particle system to simulat space wrap effect
3. trail renderer of bullets
4. skybox to make the background look like the space visuals
5. cinimachine and timeline to make the camera view looks smoothly
# storyboard
1.scene1: the fleet fly forward and a camera view is infront of them.
![1](https://user-images.githubusercontent.com/55754978/168894476-cd8c42af-c640-4f55-843e-17e2a374d7d6.png)
2.scene2: view of one of the guard ship
![2](https://user-images.githubusercontent.com/55754978/168894641-6adee46b-351b-4933-977d-ede92a4ad8d1.png)
3.scene3: enemies move forward to the fleet
![3](https://user-images.githubusercontent.com/55754978/168894758-5018aabb-f833-41d6-8e6a-8e08ccb7372c.png)
4.scene4: enemies fight with guards
![4](https://user-images.githubusercontent.com/55754978/168894996-4b1b3873-98fc-4f34-ac21-2bc771afed97.png)
5.scene5: character ship view
![5](https://user-images.githubusercontent.com/55754978/168895200-d493fe28-8969-4422-874b-f0d07c276989.png)
6.scene5: view of one of the gurad ship
![6](https://user-images.githubusercontent.com/55754978/168895333-03a5be83-815f-4ab0-820b-9e5b211020ee.png)
7.scene7: character ship space wrap view
![7](https://user-images.githubusercontent.com/55754978/168895483-260f63f9-efe1-43a8-ae5d-c27462d8f934.png)
8.scene8: teleport character 
![8](https://user-images.githubusercontent.com/55754978/168895619-f02b5ca6-f117-453d-aa4d-9c2a7ff639f5.png)
9 scene9: some free view (you can stop playing at some time because it is very long)







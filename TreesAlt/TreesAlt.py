class Node:
    def __init__(self, info): 
        self.info = info  
        self.left = None  
        self.right = None 
        self.level = None 

    def __str__(self):
        return str(self.info) 

class BinarySearchTree:
    def __init__(self): 
        self.root = None

    def create(self, val):  
        if self.root == None:
            self.root = Node(val)
        else:
            current = self.root
         
            while True:
                if val < current.info:
                    if current.left:
                        current = current.left
                    else:
                        current.left = Node(val)
                        break
                elif val > current.info:
                    if current.right:
                        current = current.right
                    else:
                        current.right = Node(val)
                        break
                else:
                    break

"""
Node is defined as
self.left (the left child of the node)
self.right (the right child of the node)
self.info (the value of the node)
"""
"""
Tree: Preorder Traversal
"""
def preOrder(root):
    if root:
        stack = [root]
        while stack:
            node = stack.pop()
            print(node.info, end=" ")
            if node.right:
                stack.append(node.right)
            if node.left:
                stack.append(node.left)
  
"""
Tree: Inorder Traversal
"""
def intOrder(root):
    if root:
        stack = []
        node = root
        while stack or node:
            if node:
                stack.append(node)
                node = node.left
            else:
                node = stack.pop()
                print(node.info, end=" ")
                node = node.right
  
"""
Tree: Post Traversal
"""
def postOrder(root):
    if root:
        stack = []
        node = root
        while stack or node:
            if node:
                stack.append(node)
                node = node.left
            else:
                node = stack.pop()
                print(node.info, end=" ")
                node = node.right


tree = BinarySearchTree()

t = int("6")

arr = list(map(int, "1 2 5 3 6 4".split()))

for i in range(t):
    tree.create(arr[i])

postOrder(tree.root)
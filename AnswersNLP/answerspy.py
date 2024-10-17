import spacy
import re


nlp = spacy.load("en_core_web_sm")

# with open("answers.txt", "r") #as file:
#     answers = file.readlines()

# answers = [answer.strip() #for answer in answers if #answer.strip()]

# cleaned# #_answers = [
#     re.sub(r"[^\w\s]", "", answer.strip()) for answer in answers if answer.strip()
# ]  # re in use, to return the nswers as regular expressiiuon, that is without puntuations and special chracters


# #tokenized_answers = #[nlp(answer) for answer in answers]


#     print(f"Answer {i + 1}: {[token.text for token in answer]}")


with open("answers.txt", "r") as file:
    answers = file.readlines()  # Read lines as a list

cleaned_answers = []
for answer in answers:
    cleaned_answer = re.sub(r"[^\w\s]", "", answer.strip())  # Remove punctuation
    if cleaned_answer:
        cleaned_answers.append(cleaned_answer)


tokenized_answers = [nlp(answer) for answer in cleaned_answers]


for i, answer in enumerate(tokenized_answers):
    print(
        f"Answer {i + 1}: {[token.text for token in answer]}"
    )  # terminal log to ensure correct answers

with open("tokenized_answers.txt", "w") as f:
    for answer in tokenized_answers:
        tokens = [token.text for token in answer]  # Get the tokens as text
        f.write(" ".join(tokens) + "\n")

# next step, new shhii
from transformers import pipeline

# Load the summarization pipeline
summarizer = pipeline("summarization", model="t5-small")

# Read original answers file not the tokenized file
with open("answers.txt", "r") as file:
    original_answers = file.read()

# Summarize the original answers
summary = summarizer(original_answers, max_length=150, min_length= 10, do_sample=False)[
    0
]["summary_text"]

# save into a separate file as well
with open("summarized_answers.txt", "w") as file:
    file.write(summary)

print("Summary:", summary)
